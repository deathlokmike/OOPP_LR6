// MFCLibrary.cpp: определяет процедуры инициализации для библиотеки DLL.
//

#include "pch.h"
#include "framework.h"
#include "MFCLibrary.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

//
//TODO: если эта библиотека DLL динамически связана с библиотеками DLL MFC,
//		все функции, экспортированные из данной DLL-библиотеки, которые выполняют вызовы к
//		MFC, должны содержать макрос AFX_MANAGE_STATE в
//		самое начало функции.
//
//		Например:
//
//		extern "C" BOOL PASCAL EXPORT ExportedFunction()
//		{
//			AFX_MANAGE_STATE(AfxGetStaticModuleState());
//			// тело нормальной функции
//		}
//
//		Важно, чтобы данный макрос был представлен в каждой
//		функции до вызова MFC.  Это означает, что
//		должен стоять в качестве первого оператора в
//		функции и предшествовать даже любым объявлениям переменных объекта,
//		поскольку их конструкторы могут выполнять вызовы к MFC
//		DLL.
//
//		В Технических указаниях MFC 33 и 58 содержатся более
//		подробные сведения.
//

// CMFCLibraryApp

BEGIN_MESSAGE_MAP(CMFCLibraryApp, CWinApp)
END_MESSAGE_MAP()


// Создание CMFCLibraryApp

CMFCLibraryApp::CMFCLibraryApp()
{
	// TODO: добавьте код создания,
	// Размещает весь важный код инициализации в InitInstance
}


// Единственный объект CMFCLibraryApp

CMFCLibraryApp theApp;


// Инициализация CMFCLibraryApp

BOOL CMFCLibraryApp::InitInstance()
{
	CWinApp::InitInstance();

	return TRUE;
}
struct CppStruct
{
	char name[100];
	int year;
	double strt_prc;
	int torque;
	int engine_power;
};
extern "C"
{
	_declspec(dllexport) void load(const char* fileName)
	{
		AFX_MANAGE_STATE(AfxGetStaticModuleState());

		cars.load(fileName);
	}

	_declspec(dllexport) void save(const char* fileName)
	{
		AFX_MANAGE_STATE(AfxGetStaticModuleState());

		cars.save(fileName);
	}

	_declspec(dllexport) void clear()
	{
		cars.clear();
	}

	_declspec(dllexport) int getSize()
	{
		return cars.getSize();
	}

	_declspec(dllexport) void GetStruct(CppStruct& s, int n)
	{
		strcpy(s.name, cars.motorshow[n]->name);
		s.year = cars.motorshow[n]->year;
		s.strt_prc = cars.motorshow[n]->strt_prc;
		if (cars.getType(n) != 0)
		{
			s.torque = static_pointer_cast<SportCarDrozdov>(cars.motorshow[n])->torque;
			s.engine_power = static_pointer_cast<SportCarDrozdov>(cars.motorshow[n])->engine_power;
		}
	}
	_declspec(dllexport) void SetStruct(CppStruct& s, int n)
	{
		if (s.torque == 0)
		{
			cars.addCar();
			cars.motorshow[n]->name = s.name;
			cars.motorshow[n]->year = s.year;
			cars.motorshow[n]->strt_prc = s.strt_prc;
		}
		else
		{
			cars.addSportCar();
			cars.motorshow[n]->name = s.name;
			cars.motorshow[n]->year = s.year;
			cars.motorshow[n]->strt_prc = s.strt_prc;
			static_pointer_cast<SportCarDrozdov>(cars.motorshow[n])->torque = s.torque;
			static_pointer_cast<SportCarDrozdov>(cars.motorshow[n])->engine_power = s.engine_power;
		}

	}
}