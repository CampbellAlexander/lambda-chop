using System;

namespace LambdaChop
{
    public sealed class Lazy<T>
    {
        private Func<T> expression;
        public T Value => expression.Invoke();

        public Lazy(Func<T> expression)
        {
            this.expression = () =>
            {
                T value = expression.Invoke();
                this.expression = () => value;
                return value;
            };
        }
    }
}
