package md5ff0884bf2c1fa4baaa0709a2acca3a59;


public class FirebaseIIDService
	extends com.google.firebase.iid.FirebaseInstanceIdService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTokenRefresh:()V:GetOnTokenRefreshHandler\n" +
			"";
		mono.android.Runtime.register ("Cogent_Deals.Droid.FirebaseIIDService, Cogent Deals, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", FirebaseIIDService.class, __md_methods);
	}


	public FirebaseIIDService () throws java.lang.Throwable
	{
		super ();
		if (getClass () == FirebaseIIDService.class)
			mono.android.TypeManager.Activate ("Cogent_Deals.Droid.FirebaseIIDService, Cogent Deals, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onTokenRefresh ()
	{
		n_onTokenRefresh ();
	}

	private native void n_onTokenRefresh ();

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
