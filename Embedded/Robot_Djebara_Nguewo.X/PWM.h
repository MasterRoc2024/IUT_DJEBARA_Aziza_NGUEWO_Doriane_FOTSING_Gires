/* 
 * File:   PMW.h
 * Author: Table2
 *
 * Created on 17 novembre 2023, 09:14
 */

#ifndef PMW_H
#define	PMW_H

#define MOTEUR_GAUCHE 49
#define MOTEUR_DROIT 3

void InitPWM(void);
void PWMUpdateSpeed();
void  PWMSetSpeedConsigne(float vitesseEnPourcents, char moteur);
//void PWMSetSpeed(float vitesseEnPourcents, unsigned char motorNb);

#endif	/* PMW_H */


