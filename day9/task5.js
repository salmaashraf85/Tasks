let theNumber = 100020003000;

let set=new Set(theNumber.toString());
let arr=Array.from(set).filter(x=>x!=0);
let result=Number(arr.join(""));
console.log(result);



//another solution 
let result2=Number([...new Set(theNumber.toString())].filter(x=>x!=0).sort((a,b)=>a-b).join(""));
console.log(result2);
   
