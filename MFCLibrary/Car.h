#pragma once
#include "framework.h"
using namespace std;

class vehicleDrozdov: public CObject
{
public:
	CString name;
	int year = 0;
	int strt_prc = 0;
	DECLARE_SERIAL(vehicleDrozdov)
	vehicleDrozdov() {}
	virtual ~vehicleDrozdov() {}
	virtual void Serialize(CArchive& ar);
};
