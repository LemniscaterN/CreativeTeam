/*
    学籍番号 : 11870273
    名前     : 宮本 拓実
    課題     : list 7-4
    作成日   : 2018/
*/

#include<stdio.h>

int main(void){
  int na,nb;
  double dx,dy;

  printf("sizeof(int) = %u\n",(unsigned)sizeof(int));
  printf("sizeof(double) = %u\n",(unsigned)sizeof(double));

  printf("sizeof(na) = %u\n",(unsigned)sizeof(na));
  printf("sizeof(dx) = %u\n",(unsigned)sizeof(dx));

  printf("sizeof(int) = %u\n",(unsigned)sizeof(na+nb));
  printf("sizeof(int) = %u\n",(unsigned)sizeof(na+dy));
  printf("sizeof(int) = %u\n",(unsigned)sizeof(dx+dy));

  return 0;
}
