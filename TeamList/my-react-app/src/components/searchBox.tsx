import { TextField, InputAdornment } from '@mui/material';
import SearchIcon from '@mui/icons-material/Search';
import { useTranslation } from 'react-i18next';
const SearchInputBox = () => {
    const {t}=useTranslation();
  return (
    <TextField
      placeholder= {t('button.search')}
      variant="outlined"
      size="small"
      InputProps={{
        startAdornment: (
          <InputAdornment position="start">
            <SearchIcon fontSize="small" />
          </InputAdornment>
        ),
      }}
      sx={{
        width: 300, 
        '& .MuiOutlinedInput-root': {
          borderRadius: '20px', 
          backgroundColor: '#f5f5f5', 
        },
        '& .MuiOutlinedInput-notchedOutline': {
          border: 'none', 
        }
      }}
    />
  );
};

export default SearchInputBox;