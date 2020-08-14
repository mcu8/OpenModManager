using Microsoft.Win32.SafeHandles;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ModdingTools.Engine 
{
	// adapted from UnrealFrontend, for handling cooking&compiling output
	public class NamedPipe : IDisposable
	{
		[StructLayout(LayoutKind.Sequential)]
		public class Overlapped
		{
		}

		public const int INVALID_HANDLE_VALUE = -1;

		public const uint PIPE_ACCESS_INBOUND = 1u;

		public const uint PIPE_TYPE_BYTE = 0u;

		public const uint PIPE_READMODE_BYTE = 0u;

		private const uint BUFFER_SIZE = 1024u;

		private SafePipeHandle PipeHandle;

		[DllImport("kernel32", SetLastError = true)]
		public static extern SafePipeHandle CreateNamedPipe(string lpName, uint dwOpenMode, uint dwPipeMode, uint nMaxInstances, uint nOutBufferSize, uint nInBufferSize, uint nDefaultTimeOut, IntPtr pipeSecurityDescriptor);

		[DllImport("kernel32", SetLastError = true)]
		public static extern bool ConnectNamedPipe(SafePipeHandle hHandle, Overlapped lpOverlapped);

		[DllImport("kernel32", SetLastError = true)]
		public static extern bool DisconnectNamedPipe(SafePipeHandle hHandle);

		[DllImport("kernel32", SetLastError = true)]
		public static extern bool ReadFile(SafePipeHandle hHandle, byte[] lpBuffer, uint nNumberOfBytesToRead, byte[] lpNumberOfBytesRead, uint lpOverlapped);

		public void Disconnect()
		{
			DisconnectNamedPipe(PipeHandle);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				PipeHandle.Dispose();
			}
		}

		public bool Connect(Process ClientProcess)
		{
			try
			{
				string lpName = "\\\\.\\pipe\\" + ClientProcess.Id + "cout";
				PipeHandle = CreateNamedPipe(lpName, 1u, 0u, 1u, 1024u, 1024u, 1000u, IntPtr.Zero);
				if (PipeHandle.IsInvalid)
				{
					return false;
				}
				ConnectNamedPipe(PipeHandle, null);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public string Read()
		{
			byte[] array = new byte[1025];
			byte[] array2 = new byte[4];
			string text = "";
			ReadFile(PipeHandle, array, 1024u, array2, 0u);
			int num = array2[0] + (array2[1] << 8) + (array2[2] << 16) + (array2[3] << 24);
			for (int i = 0; i < num; i += 2)
			{
				int num2 = array[i] + (array[i + 1] << 8);
				text += (char)num2;
			}
			return text;
		}
	}
}
