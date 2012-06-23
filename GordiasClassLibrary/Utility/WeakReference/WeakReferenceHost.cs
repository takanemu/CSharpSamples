
namespace GordiasClassLibrary.Utility.WeakReference
{
    using System;

    /// <summary>
    /// 弱参照ホストクラス
    /// </summary>
    /// <typeparam name="GuestType">ゲストクラス型</typeparam>
    public class WeakReferenceHost<GuestType> where GuestType : class, IWeakReferenceGuest, new()
    {
        /// <summary>
        /// ゲストオブジェクトへの弱い参照
        /// </summary>
        private WeakReference weakReference;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public WeakReferenceHost()
        {
            GuestType guest = this.CreateInstance(true);
            this.weakReference = new WeakReference(guest);
            guest = null;
        }

        /// <summary>
        /// ゲストオブジェクトを使うメソッド
        /// </summary>
        public void Use(Action<GuestType> action)
        {
            GuestType guest = (GuestType)this.weakReference.Target;

            if (guest == null)
            {
                guest = this.CreateInstance(false);
                this.weakReference.Target = guest;
            }
            action(guest);

            guest = null;
        }

        /// <summary>
        /// ゲストオブジェクトを生成するメソッド
        /// </summary>
        /// <returns>ゲストクラスインスタンス</returns>
        private GuestType CreateInstance(bool first)
        {
            GuestType guest = new GuestType();

            if (guest is IWeakReferenceGuest)
            {
                ((IWeakReferenceGuest)guest).Initialize(first);
            }
            return guest;
        }
    }
}
