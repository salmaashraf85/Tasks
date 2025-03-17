let result=document.querySelector('.exchange');
let input=document.querySelector('input');

input.addEventListener("input",function(){
   let calc=input.value*50.47;
   result.innerHTML=(`${input.value} USD dollar = ${calc.toFixed(2)} Egyptian pound `);
})
