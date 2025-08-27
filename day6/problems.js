//task1
let mix=[1,2,3,"E",4,"l","z","e","r",5,"o"];

let filteredMix=mix.filter((x) => typeof x ==="string"
).join("");
console.log(filteredMix);

//task2
let myString="EELLLzzzzzzzeroo";
let repeat=[];
let myString2=myString.split("").reduce((result,x) =>{
   if(!(result.includes(x))){
        result +=x;
   }
   return result;
},"");
console.log(myString2);

//task3
function totalVotes(arr) {
    let numVotes=arr.reduce((votes,x)=> x.voted ? votes+=1:votes,0);
 return numVotes;
}

var voters = [
    {name: 'Bob', age: 30, voted: true},
    {name: 'Jake', age: 32, voted: true},
    {name: 'Kate', age: 25, voted: false},
    {name: 'Sam', age: 20, voted: false},
    {name: 'Phil', age: 21, voted: true},
    {name: 'Ed', age: 55, voted: true},
    {name: 'Tami', age: 54, voted: true},
    {name: 'Mary', age: 31, voted: false},
    {name: 'Becky', age: 43, voted: false},
    {name: 'Joey', age: 41, voted: true},
    {name: 'Jeff', age: 30, voted: true},
    {name: 'Zack', age: 19, voted: false}
];

console.log(totalVotes(voters)); // Expected output: 7




