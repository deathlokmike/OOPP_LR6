#include "pch.h"
#include "SportCar.h"

IMPLEMENT_SERIAL(SportCarDrozdov, vehicleDrozdov, VERSIONABLE_SCHEMA | 0);

void SportCarDrozdov::Serialize(CArchive& ar)
{
	vehicleDrozdov::Serialize(ar);
	if (ar.IsStoring())
	{
		ar << engine_power;
		ar << torque;
	}
	else
	{
		ar >> engine_power;
		ar >> torque;
	}
}
