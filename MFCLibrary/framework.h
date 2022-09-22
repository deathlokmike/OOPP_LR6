﻿#pragma once

#ifndef VC_EXTRALEAN
#define VC_EXTRALEAN            // Исключите редко используемые компоненты из заголовков Windows
#endif

#include "targetver.h"

#define _CRT_SECURE_NO_WARNINGS
#define _ATL_CSTRING_EXPLICIT_CONSTRUCTORS      // некоторые конструкторы CString будут явными

#include <afxwin.h>         // основные и стандартные компоненты MFC
#include <afxext.h>         // Расширения MFC

#ifndef _AFX_NO_OLE_SUPPORT
#include <afxole.h>         // классы MFC OLE
#include <afxodlgs.h>       // классы диалоговых окон MFC OLE
#include <afxdisp.h>        // классы автоматизации MFC
#endif // _AFX_NO_OLE_SUPPORT

#ifndef _AFX_NO_DB_SUPPORT
#include <afxdb.h>                      // классы баз данных MFC ODBC
#endif // _AFX_NO_DB_SUPPORT

#ifndef _AFX_NO_DAO_SUPPORT
#include <afxdao.h>                     // классы баз данных MFC DAO
#endif // _AFX_NO_DAO_SUPPORT

#ifndef _AFX_NO_OLE_SUPPORT
#include <afxdtctl.h>           // поддержка MFC для типовых элементов управления Internet Explorer 4
#endif
#ifndef _AFX_NO_AFXCMN_SUPPORT
#include <afxcmn.h>                     // поддержка MFC для типовых элементов управления Windows
#endif // _AFX_NO_AFXCMN_SUPPORT

#include <string>
#include <vector>
#include <memory>
#include <afxcontrolbars.h>
#include <atlstr.h> 
