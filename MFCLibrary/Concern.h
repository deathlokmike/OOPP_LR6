#pragma once
#include "Car.h"
#include "SportCar.h"

class ConcernDrozdov
{
public:
	vector<shared_ptr<vehicleDrozdov>> motorshow;
	void clear();
	size_t getSize();
	int getType(int n);
	void save(const char* fileName);
	void load(const char* fileName);
	void addCar();
	void addSportCar();
};
