/* 
 * File:   CB_TX1.h
 * Author: Table2
 *
 * Created on 16 avril 2024, 11:49
 */

#ifndef CB_TX1_H
#define	CB_TX1_H

#ifdef	__cplusplus
extern "C" {
#endif


void SendMessage(unsigned char* message, int length);
void CB_TX1_Add(unsigned char value);
unsigned char CB_TX1_IsTranmitting(void);
void __attribute__((interrupt, no_auto_psv)) _U1TXInterrupt(void);
void SendOne();
int CB_TX1_GetDataSize(void);
int CB_TX1_GetRemainingSize(void);

#ifdef	__cplusplus
}
#endif

#endif	/* CB_TX1_H */

