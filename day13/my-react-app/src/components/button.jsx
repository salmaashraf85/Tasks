import { Button } from '@mui/material';

const MyButton = ({ onClick, children }) => {
  return (
    <Button variant="contained" color="primary" onClick={onClick}>
      {children}
    </Button>
  );
};

export default MyButton;