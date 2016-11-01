
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
STDMETHODIMP HelloCom::QueryInterface(REFIID comInterfaceId, void **ppComInterface)
{
	IUnknown *pUnk = nullptr;
	if (comInterfaceId == IID_IUnknown || comInterfaceId == CLSID_IHelloCom)
	{
		//cast to IHelloCom COM interface
		pUnk = static_cast<IHelloCom*>(this);
	}
	//pointer of pointer , so we assign pointer to it
	//pointer to COM interface object pointer
	*ppComInterface = pUnk;

	if (!pUnk)
	{
		//error no interface
		return E_NOINTERFACE;
	}

	//add reference counter
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


STDMETHODIMP  HelloCom::SayHello(BSTR * outputString)
{
	//we change value of address that outputString point to
	//pointer to Binary string, so we change value of that address with new binary string
	*outputString = SysAllocString(L"Hello World");
	return S_OK;
}
