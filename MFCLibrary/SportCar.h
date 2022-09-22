#pragma once
#include "Car.h"

class SportCarDrozdov : public vehicleDrozdov
{
public:
	int engine_power = 0;
	int torque = 0;
	DECLARE_SERIAL(SportCarDrozdov)
	SportCarDrozdov() {};
	virtual ~SportCarDrozdov() {};
	virtual void Serialize(CArchive& ar);
};

