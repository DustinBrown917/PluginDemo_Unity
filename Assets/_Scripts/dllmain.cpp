// dllmain.cpp : Defines the entry point for the DLL application.

#include <stdint.h>
#include <stdlib.h>

#define DllExport __declspec (dllexport)

extern "C" {

	DllExport const int GetVal(int vals[], float weights[], int count) {
		float sum = 0.0f;
		for (int i = 0; i < count; i++) {
			sum += weights[i];
		}

		float r = static_cast <float> (rand()) / (static_cast <float> (RAND_MAX / sum));

		int index = 0;

		for (int i = 0; i < count; i++) {
			r -= weights[i];
			if (r <= 0) {
				index = i;
				break;
			}
		}

		return vals[index];
	}

}

