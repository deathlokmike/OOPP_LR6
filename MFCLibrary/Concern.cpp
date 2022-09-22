#include "pch.h"
#include "Concern.h"

void ConcernDrozdov::clear()
{
	motorshow.clear();
}

void ConcernDrozdov::addCar()
{
	motorshow.push_back(make_shared<vehicleDrozdov>());
}

void ConcernDrozdov::addSportCar()
{
	motorshow.push_back(make_shared<SportCarDrozdov>());
}

size_t ConcernDrozdov::getSize()
{
	return motorshow.size();
}

int ConcernDrozdov::getType(int n)
{
	return motorshow[n]->IsKindOf(RUNTIME_CLASS(SportCarDrozdov)) != 0;
}

void ConcernDrozdov::save(const char* fileName)
{
	CFile file(CString(fileName), CFile::modeCreate | CFile::modeWrite);
	CArchive archive(&file, CArchive::store);
	archive << getSize();
	for (int i = 0; i < getSize(); i++)
	{
		archive << motorshow[i].get();
	}
}

void ConcernDrozdov::load(const char* fileName)
{
	clear();
	CFile file(CString(fileName), CFile::modeRead);
	CArchive archive(&file, CArchive::load);
	int size;
	archive >> size;
	for (int i = 0; i < size; i++)
	{
		vehicleDrozdov* car;
		archive >> car;
		motorshow.push_back(shared_ptr<vehicleDrozdov>(car));
	}
}