#include<stdio.h>
#include<math.h>
int main()
{
  int n,k,i,j;
  printf("‰½Œ³˜A—§ˆêŸ•û’ö®‚Å‚·‚©H”š‚ğ“ü—Í‚µ‚Ä‚­‚¾‚³‚¢\n");
  scanf("%d",&n);
  float A[n][n],M[n][n],b[n],x[n],w,sum=0;
  printf("A‚É‚Â‚¢‚Ä“ü—Í‚µ‚Ä‚­‚¾‚³‚¢\n");
  for(i=0;i<=n-1;i++){
    for(j=0;j<=n-1;j++){
    scanf("%f",&A[i][j]);
    }
  }

  printf("b‚É‚Â‚¢‚Ä“ü—Í‚µ‚Ä‚­‚¾‚³‚¢\n");
  for(i=0;i<=n-1;i++){
  scanf("%f",&b[i]);
 }

  for(k=0;k<=n-2;k++){
   w=1/A[k][k];
   for(i=k+1;i<=n-1;i++){
    M[i][k]=A[i][k]*w;
    for(j=k+1;j<=n-1;j++){
     A[i][j]=A[i][j]-M[i][k]*A[k][j];
    }
    b[i]=b[i]-M[i][k]*b[k];
   }
  }

  x[n-1]=b[n-1]/A[n-1][n-1];
  for(i=n-2;i>=0;i--){
    for(j=i+1;j<=n-1;j++){
      sum+=A[i][j]*x[j];
    }
    x[i]=(b[i]-sum)/A[i][i];
    sum=0;
  }

  printf("x=  ");
  for(i=0;i<=n-1;i++){
   printf("%f  ",x[i]);
  }
  printf("\n");

  return 0;
}
