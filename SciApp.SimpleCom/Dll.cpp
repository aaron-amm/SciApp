#include "Precompiled.h"
#include "Dll.h"
#include "ClassFactory.h"
#include "HelloCom.h"

//anonymous namespace private to source file
namespace {

	LONG dllObjCount = 0;
	ClassFactory dllClassFactory;

}

void DllAddRef() {
	InterlockedIncrement(&dllObjCount);
}

void DllRelease() {
	ASSERT(dllObjCount > 0);
	InterlockedDecrement(&dllObjCount);
}

//
// STDAPI == extern "C" HRESULT __stdcall
//

STDAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, void **ppvObj)
{
	if (rclsid == CLSID_HelloCom) 
	{
		return dllClassFactory.QueryInterface(riid, ppvObj);
	}
	
	*ppvObj = nullptr;
	return CLASS_E_CLASSNOTAVAILABLE;
}

STDAPI DllCanUnloadNow()
{
	return (dllObjCount == 0) ? S_OK : S_FALSE;
}
