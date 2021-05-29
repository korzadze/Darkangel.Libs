using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Darkangel.CommandLine
{
    /// <summary>
    /// <para>Список опций командной строки</para>
    /// </summary>
    public class OptionCollection : IEnumerable<Option>
    {
        private readonly List<Option> _Items = new();
        private readonly Dictionary<char, Option> _ByShort = new();
        private readonly Dictionary<string, Option> _ByLong = new();
        /// <inheritdoc/>
        public IEnumerator<Option> GetEnumerator() =>
            ((IEnumerable<Option>)_Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() =>
            ((IEnumerable)_Items).GetEnumerator();
        /// <summary>
        /// <para>Добавить опцию к списку</para>
        /// </summary>
        /// <param name="option">Опция командной строки</param>
        /// <returns>Список опций командной строки</returns>
        public OptionCollection Append(Option option)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = option ?? throw new ArgumentNullException(nameof(option));
#endif
            #endregion Проверка аргументов
            if (option.ShortName.HasValue)
            {
                _ByShort[option.ShortName.Value] = option;
            }
            if (!string.IsNullOrEmpty(option.LongName))
            {
                _ByLong[option.LongName] = option;
            }
            _Items.Add(option);
            return this;
        }
        /// <summary>
        /// <para>Добавить опцию в список</para>
        /// </summary>
        /// <param name="list">Список опций</param>
        /// <param name="opt">Опция командной строки</param>
        /// <returns>Список опций командной строки</returns>
        public static OptionCollection operator +(OptionCollection list, Option opt) =>
            list.Append(opt);
        /// <summary>
        /// <para>Обработать аргументы командной сторки</para>
        /// </summary>
        /// <param name="args">Аргументы командной строки</param>
        /// <returns>Список обработанных аргументов командной строки</returns>
        public ArgumentCollection Parse(IEnumerable<string> args) =>
            Parse(args?.ToArray());
        private const string OptionName = "name";
        private const string OptionValue = "value";
        private const char OptionPrefix = '-';
        private static readonly Regex reLongOpt = new($"^\\-\\-(?<{OptionName}>[A-Za-z0-9][A-Za-z0-9-_@]*[A-Za-z0-9])(\\=(?<{OptionValue}>.+))?$", RegexOptions.Singleline | RegexOptions.Compiled);
        private static readonly Regex reShortOpt = new($"^\\-(?<{OptionName}>[A-Za-z0-9])$", RegexOptions.Singleline | RegexOptions.Compiled);
        /// <summary>
        /// <para>Обработать аргументы командной сторки</para>
        /// </summary>
        /// <param name="args">Аргументы командной строки</param>
        /// <returns>Список обработанных аргументов командной строки</returns>
        public ArgumentCollection Parse(params string[] args)
        {
            ArgumentCollection res = new();
            #region Проверка аргументов
#if CHECK_ARGS
            _ = args ?? throw new ArgumentNullException(nameof(args));
#else
            if (args is null) return res;
#endif
            #endregion
            var argIx = 0;
            #region Работаем, пока есть данные
            while (argIx < args.Length)
            {
                var arg = args[argIx++];
                #region Это опция
                if (arg.StartsWith(OptionPrefix))
                {
                    #region Особый случай для stdin/stdout
                    if (arg.Length == 1)
                    {
                        res.Add(new Argument(null, arg));
                        continue;
                    }
                    #endregion
                    #region Это "короткая" опция
                    var m = reShortOpt.Match(arg);
                    if (m.Success)
                    {
                        var name = m.Groups[OptionName].Value[0];
                        #region Неизвестная опция
                        if (!_ByShort.ContainsKey(name))
                        {
                            throw new UnknownOptionException(arg);
                        }
                        #endregion
                        var opt = _ByShort[name];
                        #region Значение не нужно
                        if (opt.Mode == OptionValueMode.ValueDenied)
                        {
                            res.Add(new Argument(opt, null));
                            continue;
                        }
                        #endregion
                        #region ...или, таки, нужно
                        else
                        {
                            #region Достигнут конец командной строки
                            if (argIx >= args.Length)
                            {
                                if (opt.Mode == OptionValueMode.ValueOptional)
                                {//значение опционально
                                    res.Add(new Argument(opt, null));
                                    continue;
                                }
                                else
                                {//значение обязательно
                                    throw new OptionRequiredValueException(arg);
                                }
                            }
                            #endregion
                            #region или еще есть, что обработать
                            else
                            {
                                var value = args[argIx++];
                                #region Возможное значение начинается с символа опции
                                if (value.StartsWith(OptionPrefix))
                                {
                                    switch (opt.Mode)
                                    {
                                        case OptionValueMode.ValueRequired:
                                            throw new OptionValueException($"{arg} => {value}");
                                        case OptionValueMode.ValueOptional:
                                            argIx--;
                                            continue;
                                    }
                                }
                                #endregion
                                #region ...или нет
                                else
                                {
                                    switch (opt.Mode)
                                    {
                                        case OptionValueMode.ValueRequired:
                                        case OptionValueMode.ValueOptional:
                                            res.Add(new Argument(opt, value));
                                            continue;
                                    }
                                }
                                #endregion
                            }
                            #endregion
                        }
                        #endregion
                        #region Отлавливаем недоработки
                        throw new InvalidProgramException($"BUGTRAP: {arg}");
                        #endregion
                    }
                    #endregion
                    #region ... или это "длинная" опция
                    m = reLongOpt.Match(arg);
                    if (m.Success)
                    {
                        var name = m.Groups[OptionName].Value;
                        #region Неизвестная опция
                        if (!_ByLong.ContainsKey(name))
                        {
                            throw new UnknownOptionException(arg);
                        }
                        #endregion
                        var opt = _ByLong[name];
                        #region Есть значение
                        if (m.Groups.ContainsKey(OptionValue))
                        {
                            var value = m.Groups[OptionValue].Value;
                            switch (opt.Mode)
                            {
                                case OptionValueMode.ValueDenied:
                                    throw new OptionValueException(arg);
                                case OptionValueMode.ValueOptional:
                                case OptionValueMode.ValueRequired:
                                    res.Add(new Argument(opt, value));
                                    continue;
                            }
                        }
                        #endregion
                        #region ...или нет
                        else
                        {
                            switch (opt.Mode)
                            {
                                case OptionValueMode.ValueRequired:
                                    throw new OptionValueException(arg);
                                case OptionValueMode.ValueDenied:
                                case OptionValueMode.ValueOptional:
                                    continue;
                            }
                        }
                        #endregion
                        #region Отлавливаем недоработки
                        throw new InvalidProgramException($"BUGTRAP: {arg}");
                        #endregion
                    }
                    #endregion
                    #region ... или это неизвестная опция
                    throw new UnknownOptionException(arg);
                    #endregion
                }
                #endregion
                #region ... или это значение
                else
                {
                    res.Add(new Argument(null, arg));
                }
                #endregion
            }
            #endregion
            return res;
        }
    }
}
