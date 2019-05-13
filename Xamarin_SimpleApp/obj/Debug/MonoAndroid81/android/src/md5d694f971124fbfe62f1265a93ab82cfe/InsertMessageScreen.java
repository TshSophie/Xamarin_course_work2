package md5d694f971124fbfe62f1265a93ab82cfe;


public class InsertMessageScreen
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("_04_Xamarin.InsertMessageScreen, 04_Xamarin", InsertMessageScreen.class, __md_methods);
	}


	public InsertMessageScreen ()
	{
		super ();
		if (getClass () == InsertMessageScreen.class)
			mono.android.TypeManager.Activate ("_04_Xamarin.InsertMessageScreen, 04_Xamarin", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
