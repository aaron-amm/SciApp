#pragma once
#include "Precompiled.h"

//class forward declaration

// {B24DA285-7FA9-4A31-8E1D-478FA4DB6B10}
static const GUID CLSID_IHelloCom = { 0xb24da285, 0x7fa9, 0x4a31,{ 0x8e, 0x1d, 0x47, 0x8f, 0xa4, 0xdb, 0x6b, 0x10 } };
class IHelloCom : public IUnknown
{
public:
	virtual HRESULT __stdcall SayHello(BSTR * outputString) = 0;
};


// {DB95FAEE-4798-41F8-9F55-875F3123AF48}
static const GUID CLSID_HelloCom = { 0xdb95faee, 0x4798, 0x41f8, { 0x9f, 0x55, 0x87, 0x5f, 0x31, 0x23, 0xaf, 0x48 } };
class HelloCom
	: public IHelloCom
{
public:
	HelloCom();
	HRESULT __stdcall SayHello(BSTR * outputString);//override
	STDMETHODIMP QueryInterface(REFIID riid, void **ppvObject);
	STDMETHODIMP_(ULONG) AddRef();
	STDMETHODIMP_(ULONG) Release();

private:
	~HelloCom(); // Destructor not accessible publicly. (It's called by Release() internally)

	HelloCom(const HelloCom &); // = delete
	HelloCom& operator=(const HelloCom &); // = delete


	LONG m_refCount;                // shell extension object ref count
};
