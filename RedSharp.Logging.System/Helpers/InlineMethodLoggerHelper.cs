using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using RedSharp.Logging.Sys.Enums;

namespace RedSharp.Logging.Sys.Interfaces.Services
{
    public static class InlineMethodLoggerHelper
    {
        //=======================================================//
        // Verbose

        /// <summary>
        /// Write log with only message.
        /// </summary>
        /// <remarks>
        /// In-lined version for <see cref="LogLevel.Verbose"/> level.
        /// <br/>Include a check to avoid unneeded call.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteVerbose(this IMethodLogger logger, String message, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Verbose)
                logger.Write(LogLevel.Verbose, message, metadata);
        }

        /// <summary>
        /// Write log with string format template and one parameter.
        /// </summary>
        /// <inheritdoc cref="WriteVerbose(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteVerbose<T1>(this IMethodLogger logger, String template, T1 arg1, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Verbose)
                logger.Write(LogLevel.Verbose, template, arg1, metadata);
        }

        /// <summary>
        /// Write log with string format template and two parameters.
        /// </summary>
        /// <inheritdoc cref="WriteVerbose(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteVerbose<T1, T2>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Verbose)
                logger.Write(LogLevel.Verbose, template, arg1, arg2, metadata);
        }

        /// <summary>
        /// Write log with string format template and three parameters.
        /// </summary>
        /// <inheritdoc cref="WriteVerbose(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteVerbose<T1, T2, T3>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, T3 arg3, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Verbose)
                logger.Write(LogLevel.Verbose, template, arg1, arg2, arg3, metadata);
        }

        /// <summary>
        /// Write log with string format template and four parameters.
        /// </summary>
        /// <inheritdoc cref="WriteVerbose(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteVerbose<T1, T2, T3, T4>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Verbose)
                logger.Write(LogLevel.Verbose, template, arg1, arg2, arg3, arg4, metadata);
        }

        /// <summary>
        /// Write log with string format template and five parameters.
        /// </summary>
        /// <inheritdoc cref="WriteVerbose(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteVerbose<T1, T2, T3, T4, T5>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Verbose)
                logger.Write(LogLevel.Verbose, template, arg1, arg2, arg3, arg4, arg5, metadata);
        }

        /// <summary>
        /// Write log with string format template and set of arguments.
        /// </summary>
        /// <inheritdoc cref="WriteVerbose(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteVerbose(this IMethodLogger logger, String template, Object metadata, params Object[] arguments)
        {
            if (logger.Level <= LogLevel.Verbose)
                logger.Write(LogLevel.Verbose, String.Format(template, arguments), metadata);
        }


        //=======================================================//
        // Information

        /// <summary>
        /// Write log with only message.
        /// </summary>
        /// <remarks>
        /// In-lined version for <see cref="LogLevel.Information"/> level.
        /// <br/>Include a check to avoid unneeded call.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInformation(this IMethodLogger logger, String message, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Information)
                logger.Write(LogLevel.Information, message, metadata);
        }

        /// <summary>
        /// Write log with string format template and one parameter.
        /// </summary>
        /// <inheritdoc cref="WriteInformation(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInformation<T1>(this IMethodLogger logger, String template, T1 arg1, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Information)
                logger.Write(LogLevel.Information, template, arg1, metadata);
        }

        /// <summary>
        /// Write log with string format template and two parameters.
        /// </summary>
        /// <inheritdoc cref="WriteInformation(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInformation<T1, T2>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Information)
                logger.Write(LogLevel.Information, template, arg1, arg2, metadata);
        }

        /// <summary>
        /// Write log with string format template and three parameters.
        /// </summary>
        /// <inheritdoc cref="WriteInformation(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInformation<T1, T2, T3>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, T3 arg3, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Information)
                logger.Write(LogLevel.Information, template, arg1, arg2, arg3, metadata);
        }

        /// <summary>
        /// Write log with string format template and four parameters.
        /// </summary>
        /// <inheritdoc cref="WriteInformation(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInformation<T1, T2, T3, T4>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Information)
                logger.Write(LogLevel.Information, template, arg1, arg2, arg3, arg4, metadata);
        }

        /// <summary>
        /// Write log with string format template and five parameters.
        /// </summary>
        /// <inheritdoc cref="WriteInformation(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInformation<T1, T2, T3, T4, T5>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Information)
                logger.Write(LogLevel.Information, template, arg1, arg2, arg3, arg4, arg5, metadata);
        }

        /// <summary>
        /// Write log with string format template and set of arguments.
        /// </summary>
        /// <inheritdoc cref="WriteInformation(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInformation(this IMethodLogger logger, String template, Object metadata, params Object[] arguments)
        {
            if (logger.Level <= LogLevel.Information)
                logger.Write(LogLevel.Information, String.Format(template, arguments), metadata);
        }


        //=======================================================//
        // Debug

        /// <summary>
        /// Write log with only message.
        /// </summary>
        /// <remarks>
        /// In-lined version for <see cref="LogLevel.Debug"/> level.
        /// <br/>Include a check to avoid unneeded call.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteDebug(this IMethodLogger logger, String message, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Debug)
                logger.Write(LogLevel.Debug, message, metadata);
        }

        /// <summary>
        /// Write log with string format template and one parameter.
        /// </summary>
        /// <inheritdoc cref="WriteDebug(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteDebug<T1>(this IMethodLogger logger, String template, T1 arg1, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Debug)
                logger.Write(LogLevel.Debug, template, arg1, metadata);
        }

        /// <summary>
        /// Write log with string format template and two parameters.
        /// </summary>
        /// <inheritdoc cref="WriteDebug(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteDebug<T1, T2>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Debug)
                logger.Write(LogLevel.Debug, template, arg1, arg2, metadata);
        }

        /// <summary>
        /// Write log with string format template and three parameters.
        /// </summary>
        /// <inheritdoc cref="WriteDebug(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteDebug<T1, T2, T3>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, T3 arg3, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Debug)
                logger.Write(LogLevel.Debug, template, arg1, arg2, arg3, metadata);
        }

        /// <summary>
        /// Write log with string format template and four parameters.
        /// </summary>
        /// <inheritdoc cref="WriteDebug(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteDebug<T1, T2, T3, T4>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Debug)
                logger.Write(LogLevel.Debug, template, arg1, arg2, arg3, arg4, metadata);
        }

        /// <summary>
        /// Write log with string format template and five parameters.
        /// </summary>
        /// <inheritdoc cref="WriteDebug(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteDebug<T1, T2, T3, T4, T5>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Debug)
                logger.Write(LogLevel.Debug, template, arg1, arg2, arg3, arg4, arg5, metadata);
        }

        /// <summary>
        /// Write log with string format template and set of arguments.
        /// </summary>
        /// <inheritdoc cref="WriteDebug(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteDebug(this IMethodLogger logger, String template, Object metadata, params Object[] arguments)
        {
            if (logger.Level <= LogLevel.Debug)
                logger.Write(LogLevel.Debug, String.Format(template, arguments), metadata);
        }


        //=======================================================//
        // Warning

        /// <summary>
        /// Write log with only message.
        /// </summary>
        /// <remarks>
        /// In-lined version for <see cref="LogLevel.Warning"/> level.
        /// <br/>Include a check to avoid unneeded call.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteWarning(this IMethodLogger logger, String message, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Warning)
                logger.Write(LogLevel.Warning, message, metadata);
        }

        /// <summary>
        /// Write log with string format template and one parameter.
        /// </summary>
        /// <inheritdoc cref="WriteWarning(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteWarning<T1>(this IMethodLogger logger, String template, T1 arg1, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Warning)
                logger.Write(LogLevel.Warning, template, arg1, metadata);
        }

        /// <summary>
        /// Write log with string format template and two parameters.
        /// </summary>
        /// <inheritdoc cref="WriteWarning(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteWarning<T1, T2>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Warning)
                logger.Write(LogLevel.Warning, template, arg1, arg2, metadata);
        }

        /// <summary>
        /// Write log with string format template and three parameters.
        /// </summary>
        /// <inheritdoc cref="WriteWarning(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteWarning<T1, T2, T3>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, T3 arg3, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Warning)
                logger.Write(LogLevel.Warning, template, arg1, arg2, arg3, metadata);
        }

        /// <summary>
        /// Write log with string format template and four parameters.
        /// </summary>
        /// <inheritdoc cref="WriteWarning(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteWarning<T1, T2, T3, T4>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Warning)
                logger.Write(LogLevel.Warning, template, arg1, arg2, arg3, arg4, metadata);
        }

        /// <summary>
        /// Write log with string format template and five parameters.
        /// </summary>
        /// <inheritdoc cref="WriteWarning(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteWarning<T1, T2, T3, T4, T5>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Warning)
                logger.Write(LogLevel.Warning, template, arg1, arg2, arg3, arg4, arg5, metadata);
        }

        /// <summary>
        /// Write log with string format template and set of arguments.
        /// </summary>
        /// <inheritdoc cref="WriteWarning(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteWarning(this IMethodLogger logger, String template, Object metadata, params Object[] arguments)
        {
            if (logger.Level <= LogLevel.Warning)
                logger.Write(LogLevel.Warning, String.Format(template, arguments), metadata);
        }


        //=======================================================//
        // Error

        /// <summary>
        /// Write log with only message.
        /// </summary>
        /// <remarks>
        /// In-lined version for <see cref="LogLevel.Error"/> level.
        /// <br/>Include a check to avoid unneeded call.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteError(this IMethodLogger logger, String message, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Error)
                logger.Write(LogLevel.Error, message, metadata);
        }

        /// <summary>
        /// Write log with string format template and one parameter.
        /// </summary>
        /// <inheritdoc cref="WriteError(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteError<T1>(this IMethodLogger logger, String template, T1 arg1, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Error)
                logger.Write(LogLevel.Error, template, arg1, metadata);
        }

        /// <summary>
        /// Write log with string format template and two parameters.
        /// </summary>
        /// <inheritdoc cref="WriteError(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteError<T1, T2>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Error)
                logger.Write(LogLevel.Error, template, arg1, arg2, metadata);
        }

        /// <summary>
        /// Write log with string format template and three parameters.
        /// </summary>
        /// <inheritdoc cref="WriteError(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteError<T1, T2, T3>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, T3 arg3, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Error)
                logger.Write(LogLevel.Error, template, arg1, arg2, arg3, metadata);
        }

        /// <summary>
        /// Write log with string format template and four parameters.
        /// </summary>
        /// <inheritdoc cref="WriteError(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteError<T1, T2, T3, T4>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Error)
                logger.Write(LogLevel.Error, template, arg1, arg2, arg3, arg4, metadata);
        }

        /// <summary>
        /// Write log with string format template and five parameters.
        /// </summary>
        /// <inheritdoc cref="WriteError(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteError<T1, T2, T3, T4, T5>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Error)
                logger.Write(LogLevel.Error, template, arg1, arg2, arg3, arg4, arg5, metadata);
        }

        /// <summary>
        /// Write log with string format template and set of arguments.
        /// </summary>
        /// <inheritdoc cref="WriteError(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteError(this IMethodLogger logger, String template, Object metadata, params Object[] arguments)
        {
            if (logger.Level <= LogLevel.Error)
                logger.Write(LogLevel.Error, String.Format(template, arguments), metadata);
        }


        //=======================================================//
        // Critical

        /// <summary>
        /// Write log with only message.
        /// </summary>
        /// <remarks>
        /// In-lined version for <see cref="LogLevel.Critical"/> level.
        /// <br/>Include a check to avoid unneeded call.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteCritical(this IMethodLogger logger, String message, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Critical)
                logger.Write(LogLevel.Critical, message, metadata);
        }

        /// <summary>
        /// Write log with string format template and one parameter.
        /// </summary>
        /// <inheritdoc cref="WriteCritical(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteCritical<T1>(this IMethodLogger logger, String template, T1 arg1, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Critical)
                logger.Write(LogLevel.Critical, template, arg1, metadata);
        }

        /// <summary>
        /// Write log with string format template and two parameters.
        /// </summary>
        /// <inheritdoc cref="WriteCritical(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteCritical<T1, T2>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Critical)
                logger.Write(LogLevel.Critical, template, arg1, arg2, metadata);
        }

        /// <summary>
        /// Write log with string format template and three parameters.
        /// </summary>
        /// <inheritdoc cref="WriteCritical(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteCritical<T1, T2, T3>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, T3 arg3, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Critical)
                logger.Write(LogLevel.Critical, template, arg1, arg2, arg3, metadata);
        }

        /// <summary>
        /// Write log with string format template and four parameters.
        /// </summary>
        /// <inheritdoc cref="WriteCritical(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteCritical<T1, T2, T3, T4>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Critical)
                logger.Write(LogLevel.Critical, template, arg1, arg2, arg3, arg4, metadata);
        }

        /// <summary>
        /// Write log with string format template and five parameters.
        /// </summary>
        /// <inheritdoc cref="WriteCritical(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteCritical<T1, T2, T3, T4, T5>(this IMethodLogger logger, String template, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Object metadata = null)
        {
            if (logger.Level <= LogLevel.Critical)
                logger.Write(LogLevel.Critical, template, arg1, arg2, arg3, arg4, arg5, metadata);
        }

        /// <summary>
        /// Write log with string format template and set of arguments.
        /// </summary>
        /// <inheritdoc cref="WriteCritical(IMethodLogger, string, object)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteCritical(this IMethodLogger logger, String template, Object metadata, params Object[] arguments)
        {
            if (logger.Level <= LogLevel.Critical)
                logger.Write(LogLevel.Critical, String.Format(template, arguments), metadata);
        }
    }
}
