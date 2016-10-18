
#include "Precompiled.h"        // Precompiled headers
#include "Dll.h"                // For DLL global ref count
#include "HelloCom.h"     // Class header




HelloCom::HelloCom()
	: m_refCount(1)        // Constructed with ref count == 1
{
	// Update the global object count for the DLL.
	DllAddRef();
}


HelloCom::~HelloCom()
{
	// Cleanup user's file selection (if any)
	// Update the global object count for the DLL.
	DllRelease();
}



//------------------------------------------------------------------------------
//                   IUnknown Methods Implementations
//------------------------------------------------------------------------------

STDMETHODIMP HelloCom::QueryInterface(REFIID riid, void **ppvObject)
{
	IUnknown *pUnk = nullptr;
	if (riid == IID_IUnknown || riid == CLSID_IHelloCom )
	{
		pUnk = static_cast<IHelloCom*>(this);
	}

	*ppvObject = pUnk;

	if (!pUnk)
	{
		return E_NOINTERFACE;
	}

	pUnk->AddRef();
	return S_OK;
}


STDMETHODIMP_(ULONG) HelloCom::AddRef()
{
	return ++m_refCount;
}


STDMETHODIMP_(ULONG) HelloCom::Release()
{
	ASSERT(m_refCount > 0);

	ULONG refCount = --m_refCount;
	if (refCount == 0)
	{
		delete this;
	}

	return refCount;
}


STDMETHODIMP  HelloCom::SayHello(BSTR * outputString )
{
	* outputString =	SysAllocString(L"Hello World");
	return S_OK;
}
