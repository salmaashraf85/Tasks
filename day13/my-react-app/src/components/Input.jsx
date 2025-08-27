// src/components/MyTextField.jsx
import { TextField } from '@mui/material';

const MyTextField = ({
  label = '',
  value,
  onChange,
  placeholder = '',
  type = 'text',
  error = false,
  helperText = '',
  ...props
}) => {
  return (
    <TextField
      label={label}
      value={value}
      onChange={onChange}
      placeholder={placeholder}
      type={type}
      error={error}
      helperText={helperText}
      variant="outlined"
      fullWidth
      {...props}
    />
  );
};

export default MyTextField;
