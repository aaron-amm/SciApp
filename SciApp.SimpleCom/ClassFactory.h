#pragma once
#include "Precompiled.h"

class ClassFactory : public IClassFactory
{
public :
    // *** IUnknown ***
    STDMETHODIMP QueryInterface(REFIID riid, void **ppvObject);
    STDMETHODIMP_(ULONG) AddRef();
    STDMETHODIMP_(ULONG) Release();

    // *** IClassFactory ***
    STDMETHODIMP CreateInstance(IUnknown *pUnkOuter, REFIID riid, void **ppvObject);
    STDMETHODIMP LockServer(BOOL fLock);

};
