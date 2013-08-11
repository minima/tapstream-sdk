﻿using System;
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class Tapstream : MonoBehaviour
{
#if UNITY_IPHONE
	
	[DllImport ("__Internal")]
	private static extern IntPtr Config_New();

	[DllImport ("__Internal")]
	private static extern void Config_Delete(IntPtr conf);
	
	[DllImport ("__Internal")]
	private static extern void Config_SetString(IntPtr conf, string key, string val);

	[DllImport ("__Internal")]
	private static extern void Config_SetBool(IntPtr conf, string key, bool val);

	[DllImport ("__Internal")]
	private static extern void Config_SetInt(IntPtr conf, string key, int val);

	[DllImport ("__Internal")]
	private static extern void Config_SetUInt(IntPtr conf, string key, uint val);

	[DllImport ("__Internal")]
	private static extern void Config_SetDouble(IntPtr conf, string key, double val);

	[DllImport ("__Internal")]
	private static extern IntPtr Event_New(string name, bool oneTimeOnly);

	[DllImport ("__Internal")]
	private static extern void Event_Delete(IntPtr ev);

	[DllImport ("__Internal")]
	private static extern void Event_AddPairString(IntPtr ev, string key, string val);

	[DllImport ("__Internal")]
	private static extern void Event_AddPairBool(IntPtr ev, string key, bool val);

	[DllImport ("__Internal")]
	private static extern void Event_AddPairInt(IntPtr ev, string key, int val);

	[DllImport ("__Internal")]
	private static extern void Event_AddPairUInt(IntPtr ev, string key, uint val);

	[DllImport ("__Internal")]
	private static extern void Event_AddPairDouble(IntPtr ev, string key, double val);

	[DllImport ("__Internal")]
	private static extern void Tapstream_Create(string accountName, string developerSecret, IntPtr conf);

	[DllImport ("__Internal")]
	private static extern void Tapstream_FireEvent(IntPtr ev);


	public class Config
	{
		protected internal IntPtr handle = (IntPtr)0;

		public Config()
		{
			handle = Config_New();
		}

		~Config()
		{
			Config_Delete(handle);
		}
		
		public void Set(string key, object val)
		{
			Type t = val.GetType();
			if(t == typeof(string))
			{
				Config_SetString(handle, key, (string)val);
			}
			else if(t == typeof(bool))
			{
				Config_SetBool(handle, key, (bool)val);
			}
			else if(t == typeof(int) )
			{
				Config_SetInt(handle, key, (int)val);
			}
			else if(t == typeof(uint))
			{
				Config_SetUInt(handle, key, (uint)val);
			}
			else if(t == typeof(double))
			{
				Config_SetDouble(handle, key, (double)val);
			}
			else
			{
				Console.WriteLine("Tapstream config object cannot accept this type: {0}", t);
			}
		}
	}

	public class Event
	{
		protected internal IntPtr handle = (IntPtr)0;

		public Event(string name, bool oneTimeOnly)
		{
			handle = Event_New(name, oneTimeOnly);
		}

		~Event()
		{
			Event_Delete(handle);
		}

		public void AddPair(string key, object val)
		{
			Type t = val.GetType ();
			if(t == typeof(string))
			{
				Event_AddPairString(handle, key, (string)val);
			}
			else if(t == typeof(bool))
			{
				Event_AddPairBool(handle, key, (bool)val);
			}
			else if(t == typeof(int))
			{
				Event_AddPairInt(handle, key, (int)val);
			}
			else if(t == typeof(uint))
			{
				Event_AddPairUInt(handle, key, (uint)val);
			}
			else if(t == typeof(double))
			{
				Event_AddPairDouble(handle, key, (double)val);
			}
			else
			{
				Console.WriteLine("Tapstream event object cannot accept this type: {0}", t);
			}
		}
	}

	public static void Create(string accountName, string developerSecret, Config conf)
	{
		Tapstream_Create(accountName, developerSecret, conf.handle);
	}

	public static void FireEvent(Event e)
	{
		Tapstream_FireEvent(e.handle);
	}

#elif UNITY_ANDROID
	
	
	
#endif

}
