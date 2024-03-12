using System;

namespace Utils.Bindings
{
    [Serializable]
    public class boolBinding : ValueBindings<bool>
    {
        public override bool Value
        {
            get => value;
            set
            {
                this.value = value;
                if (animator != null && parameter != null)
                {
                    animator.SetBool(parameter, value);
                }
            }
        }
    }
}
