let chars = ["A", "B", "C", 20, "D", "E", 10, 15, 6];
let chars2=[];
let cnt=0;
for (const x of chars) {
    if(!isNaN(parseFloat(x))){
        chars2.unshift(x);
        cnt++;
    }
    else
    {
        chars2.push(x);
    }
}
//from index 0 to cnt 2*cnt
console.log(chars2.copyWithin(0,cnt,(2*cnt)));
