#include "pch.h"
#include "Car.h"

IMPLEMENT_SERIAL(vehicleDrozdov, CObject, 0);

void vehicleDrozdov::Serialize(CArchive& ar)
{
	if (ar.IsStoring())  
	{
		ar << year;
		ar << strt_prc; 
		ar << name;
	}
	else
	{
		ar >> year;
		ar >> strt_prc;
		ar >> name;
	}
}