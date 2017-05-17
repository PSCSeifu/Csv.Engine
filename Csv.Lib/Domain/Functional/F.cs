using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Csv.Lib.Domain.Functional
{
    public static partial class F
   {
      private static readonly Unit unit = new Unit();
      // Unit
      public static Unit Unit() => unit;

      // function manipulation 

      public static Func<T1, Func<T2, R>> Curry<T1, T2, R>(this Func<T1, T2, R> func)
          => t1 => t2 => func(t1, t2);

      public static Func<T1, Func<T2, Func<T3, R>>> Curry<T1, T2, T3, R>(this Func<T1, T2, T3, R> func)
          => t1 => t2 => t3 => func(t1, t2, t3);

      public static Func<T1, Func<T2, T3, R>> CurryFirst<T1, T2, T3, R>
         (this Func<T1, T2, T3, R> @this) => t1 => (t2, t3) => @this(t1, t2, t3);

      public static Func<T, T> Tap<T>(Action<T> act) 
         => x => { act(x); return x; };
      
      public static R Pipe<T, R>(this T @this, Func<T, R> func) => func(@this);
      
      /// <summary>
      /// Pipes the input value in the given Action, i.e. invokes the given Action on the given value.
      /// returning the input value. Not really a genuine implementation of pipe, since it combines pipe with Tap.
      /// </summary>
      public static T Pipe<T>(this T input, Action<T> func) => Tap(func)(input);

      // DATA STRUCTURES

      public static Tuple<T1, T2> Tuple<T1, T2>(T1 t1, T2 t2) => new Tuple<T1, T2>(t1, t2);

      public static KeyValuePair<K, T> Pair<K, T>(K key, T value)
         => new KeyValuePair<K, T>(key, value);

      public static IEnumerable<T> List<T>(params T[] items) => items.ToImmutableList();

      public static Func<T, IEnumerable<T>> SingletonList<T>() => (item) => ImmutableList.Create(item);

      public static IEnumerable<T> Cons<T>(this T t, IEnumerable<T> ts)
         => List(t).Concat(ts);

      public static Func<T, IEnumerable<T>, IEnumerable<T>> Cons<T>()
         => (t, ts) => t.Cons(ts);

      public static IDictionary<K, T> Map<K, T>(params KeyValuePair<K, T>[] pairs)
         => pairs.ToImmutableDictionary();

      // misc

      // Using
      public static R Using<TDisp, R>(TDisp disposable
         , Func<TDisp, R> func) where TDisp : IDisposable
      {
         using (var disp = disposable) return func(disp);
      }

      public static Unit Using<TDisp>(TDisp disposable
         , Action<TDisp> act) where TDisp : IDisposable 
         => Using(disposable, act.ToFunc());
      
      public static R Using<TDisp, R>(Func<TDisp> createDisposable
         , Func<TDisp, R> func) where TDisp : IDisposable
      {
         using (var disp = createDisposable()) return func(disp);
      }

      public static Unit Using<TDisp>(Func<TDisp> createDisposable
         , Action<TDisp> action) where TDisp : IDisposable
         => Using(createDisposable, action.ToFunc());

      // Range
      public static IEnumerable<char> Range(char from, char to)
      {
         for (var i = from; i <= to; i++) yield return i;
      }

      public static IEnumerable<int> Range(int from, int to)
      {
         for (var i = from; i <= to; i++) yield return i;
      }
   }
}


