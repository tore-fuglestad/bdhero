﻿// Copyright 2012-2014 Andrew C. Dvorak
//
// This file is part of BDHero.
//
// BDHero is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// BDHero is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with BDHero.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace NativeAPI
{
    public static class PInvokeUtils
    {
        /// <summary>
        ///     The structures returned by Windows are different sizes depending on whether
        ///     the operating system is running in 32-bit or 64-bit mode.
        /// </summary>
        public static readonly bool Is32Bit = (IntPtr.Size == 4);

        /// <summary>
        ///     Invokes the specified <paramref name="pinvokeExpr"/> containing a P/Invoke call
        ///     and throws a <see href="Win32Exception"/> if <paramref name="successCond"/> returns <c>false</c>.
        /// </summary>
        /// <typeparam name="T">Datatype returned by the P/Invoke call.</typeparam>
        /// <param name="pinvokeExpr">Expression containing a P/Invoke call.</param>
        /// <param name="successCond">Function to determine whether the P/Invoke call succeeded.</param>
        /// <returns>The return value of the P/Invoke call contained within <paramref name="pinvokeExpr"/>.</returns>
        /// <exception cref="Win32Exception">
        ///     Thrown if P/Invoke contained in the given <paramref name="pinvokeExpr"/> fails.
        /// </exception>
        public static T Try<T>(Expression<Func<T>> pinvokeExpr, Func<T, bool> successCond)
        {
            var result = pinvokeExpr.Compile().Invoke();
            if (!successCond(result))
            {
                var methodCallExpr = pinvokeExpr.Body as MethodCallExpression;
                var apiSignature = methodCallExpr != null ? methodCallExpr.Method.ToString() : null;
                ThrowLastWin32Error(apiSignature);
            }
            return result;
        }

        /// <summary>
        ///     Invokes the specified <paramref name="pinvokeExpr"/> containing a P/Invoke call
        ///     and throws a <see href="Win32Exception"/> if it returns <c>false</c>.
        /// </summary>
        /// <param name="pinvokeExpr">Expression containing a P/Invoke call that returns a <see href="bool"/>.</param>
        /// <returns>The return value of the P/Invoke call contained within <paramref name="pinvokeExpr"/>.</returns>
        /// <exception cref="Win32Exception">
        ///     Thrown if P/Invoke contained in the given <paramref name="pinvokeExpr"/> fails.
        /// </exception>
        public static bool Try(Expression<Func<bool>> pinvokeExpr)
        {
            return Try(pinvokeExpr, b => b);
        }

        /// <summary>
        ///     Invokes the specified <paramref name="pinvokeExpr"/> containing a P/Invoke call
        ///     and throws a <see href="Win32Exception"/> if it returns <see href="IntPtr.Zero"/>.
        /// </summary>
        /// <param name="pinvokeExpr">Expression containing a P/Invoke call that returns an <see href="IntPtr"/>.</param>
        /// <returns>The return value of the P/Invoke call contained within <paramref name="pinvokeExpr"/>.</returns>
        /// <exception cref="Win32Exception">
        ///     Thrown if P/Invoke contained in the given <paramref name="pinvokeExpr"/> fails.
        /// </exception>
        public static IntPtr Try(Expression<Func<IntPtr>> pinvokeExpr)
        {
            return Try(pinvokeExpr, ptr => ptr != IntPtr.Zero);
        }

        /// <summary>
        ///     Gets the error code returned by the last unmanaged function that was called using platform invoke
        ///     that has the <see href="DllImportAttribute.SetLastError"/> flag set and throws a
        ///     <see href="Win32Exception"/> containing the error code.
        /// </summary>
        /// <param name="apiSignature">String containing the API signature of the last P/Invoke call that failed.</param>
        /// <exception cref="Win32Exception">Always thrown.</exception>
        private static void ThrowLastWin32Error(string apiSignature)
        {
            var errorCode = Marshal.GetLastWin32Error();
            var message = string.Format("P/Invoke of {0} failed", apiSignature);

            // The no-arg Win32Exception() constructor automatically populates the Message property with an appropriate
            // native error message from the OS, which we can then append to our own custom error message.
            var nativeException = new Win32Exception();

            throw new Win32Exception(errorCode, string.Format("{0}: {1}", message, nativeException.Message));
        }

        /// <summary>
        ///     Convenience wrapper around <see href="Marshal.PtrToStructure(System.IntPtr,System.Type)"/>.
        ///     Marshals data from an unmanaged block of memory to a newly allocated managed object of the specified type.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of object to be created. This object must represent a formatted class or a structure.
        /// </typeparam>
        /// <param name="ptr">
        ///     A pointer to an unmanaged block of memory.
        /// </param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        ///     The parameter layout of <typeparamref name="T"/> is not sequential or explicit.-or-The <typeparamref name="T"/> parameter is a generic type. 
        /// </exception>
        public static T MarshalPtrToStruct<T>(IntPtr ptr) where T : struct
        {
            return (T) Marshal.PtrToStructure(ptr, typeof (T));
        }

        /// <summary>
        ///     Convenience wrapper around <see href="Marshal.PtrToStructure(System.IntPtr,System.Type)"/>.
        ///     Marshals data from an unmanaged block of memory to a newly allocated managed object of the specified type.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of object to be created. This object must represent a formatted class or a structure.
        /// </typeparam>
        /// <param name="ptr">
        ///     A pointer to an unmanaged block of memory.
        /// </param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        ///     The parameter layout of <typeparamref name="T"/> is not sequential or explicit.-or-The <typeparamref name="T"/> parameter is a generic type. 
        /// </exception>
        public static T MarshalPtrToObject<T>(IntPtr ptr) where T : class
        {
            return (T) Marshal.PtrToStructure(ptr, typeof (T));
        }
    }
}
