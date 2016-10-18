#include "Precompiled.h"
#include "ClassFactory.h"
#include "Dll.h"
#include "HelloCom.h"

using namespace std;

STDMETHODIMP ClassFactory::QueryInterface(REFIID riid, void **ppvObject)
{
	IUnknown *pUnk = nullptr; //unknow object pointer
	if (riid == IID_IUnknown || riid == IID_IClassFactory)
	{
		pUnk = static_cast<IClassFactory *>(this);
	}

	*ppvObject = pUnk;

	if (!pUnk)
	{
		// Unsupported interface
		return E_NOINTERFACE;
	}

	pUnk->AddRef();
	return S_OK;
}

//
// Our implementation of IClassFactory is basically a "static" object,
// so we manage its ref count in a very simple way.
//
// AddRef() will just return 2 (it's kind of like "the object is
// created with ref count == 1, and we increase it to 2, and are done),
// and Release() will just return 1 (kind of going from 2 to 1, 
// but not lower, since this object is not dynamically allocated
// and doesn't get destroyed).
//

STDMETHODIMP_(ULONG) ClassFactory::AddRef()
{
	return 2;
}


STDMETHODIMP_(ULONG) ClassFactory::Release()
{
	return 1;
}


STDMETHODIMP ClassFactory::CreateInstance(IUnknown *pUnkOuter, REFIID riid, void **ppvObject)
{
	// Clear output parameter
	*ppvObject = nullptr;
	
	if (pUnkOuter)
	{
		// We don't support aggregation
		return CLASS_E_NOAGGREGATION;
	}

	// Create ShellExtension instance on the heap, in a non-throwing way.
	// (In fact, C++ exceptions can't cross COM module boundaries).
	HelloCom * pShellExt = new(std::nothrow) HelloCom();

	if (! pShellExt) 
	{
		return E_OUTOFMEMORY;
	}

	HRESULT hr = pShellExt->QueryInterface(riid, ppvObject);
	
	// ShellExtension's constructor sets its ref count to 1;
	// ShellExtension::QueryInterface calls AddRef() internally, 
	// so we call Release() here to properly balance ref count.
	pShellExt->Release();
	
	return hr;
}

STDMETHODIMP ClassFactory::LockServer(BOOL fLock)
{
	if (fLock) 
	{
		// Increment DLL's lock count.
		DllAddRef();
	}
	else       
	{
		// Decrement DLL's lock count.
		DllRelease();
	}

	return S_OK;
}
