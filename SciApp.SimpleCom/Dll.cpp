#include "Precompiled.h"
#include "Dll.h"
#include "ClassFactory.h"
#include "HelloCom.h"

//anonymous name space private to source file
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

//set of C function to export

//STDAPI == EXTERN_C  HRESULT __stdcall
//get COM  class factory
STDAPI DllGetClassObject(REFCLSID comClassId, REFIID comClassFactoryId, void **ppComClassFactory)
{
	if (comClassId == CLSID_HelloCom)
	{
		return dllClassFactory.QueryInterface(comClassFactoryId, ppComClassFactory);
	}

	//assign address of null pointer
	*ppComClassFactory = nullptr;
	return CLASS_E_CLASSNOTAVAILABLE;
}

STDAPI DllCanUnloadNow()
{
	return (dllObjCount == 0) ? S_OK : S_FALSE;
}
