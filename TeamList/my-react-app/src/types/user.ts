export interface User {
    name: {
        title: string;
        first: string;
        last: string;
      };
    email: string;
    phone:string;
    picture:{
        thumbnail:string;
    }
    position?:string;
    status?:string;
    location: {
       street: {
          number: string ,
          name: string
        },
        city: string,
  state: string,
  country: string,
  };
  
  dob: {
        date: string,
        age: string
      },

      registered:{
        date: Date,
        age: string
      };
      

}
