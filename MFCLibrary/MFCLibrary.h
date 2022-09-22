// MFCLibrary.h: основной файл заголовка для библиотеки DLL MFCLibrary
//

#pragma once
#include "Concern.h"
#include "SportCar.h"

#ifndef __AFXWIN_H__
	#error "включить pch.h до включения этого файла в PCH"
#endif

#include "resource.h"		// основные символы


// CMFCLibraryApp
// Реализацию этого класса см. в файле MFCLibrary.cpp
//

ConcernDrozdov cars;

class CMFCLibraryApp : public CWinApp
{
public:
	CMFCLibraryApp();

// Переопределение
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
};
