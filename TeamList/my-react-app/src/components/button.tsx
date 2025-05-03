import { Button } from '@mui/material';
import React from 'react';
interface MyButton {
  //onClick: () => void;
  children: React.ReactNode;
}

const MyButton: React.FC<MyButton> = ({ children }) => {
   
  return (
    <Button variant="contained" color="primary">
      {children}
    </Button>
  );
};

export default MyButton;