let chosen = 2;

let myFriends = [
  { title: "Osama", age: 39, available: true, skills: ["HTML", "CSS"] },
  { title: "Ahmed", age: 25, available: false, skills: ["Python", "Django"] },
  { title: "Sayed", age: 33, available: true, skills: ["PHP", "Laravel"] },
];

 const{title,age,available,skills:[,second]}=myFriends[chosen-1];

let Available= available ? "Available" : "NotAvailable";

console.log(title);
console.log(age);
console.log(second);
console.log(Available);

