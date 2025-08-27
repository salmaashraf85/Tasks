import { useState } from 'react';
import './App.css';
import Box from '@mui/material/Box';
import UserListWithDepartments from './pages/usersPage';
import CustomAppBar from './components/appBar';
import { SideBar } from './components/sideBar';
import './i18n';
import { I18nextProvider } from 'react-i18next';
import i18n from './i18n';
import Drawer from '@mui/material/Drawer';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import MyButton from './components/button';
import SearchInputBox from './components/searchBox'
import { useTranslation } from 'react-i18next';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
const queryClient = new QueryClient();
function App() {
  const {t}=useTranslation();
  const [mobileOpen, setMobileOpen] = useState(false);

  const handleDrawerToggle = () => {
    setMobileOpen(!mobileOpen);
  };

  return (
    <I18nextProvider i18n={i18n}>
      <Box
        sx={{
          height: '100vh',
          width: '100%',
          display: 'flex',
          flexDirection: { xs: 'column', sm: 'row' },
          margin: 0,
          padding: 0,
          overflow: 'hidden',
        }}
      >
        <Drawer
          variant="temporary"
          open={mobileOpen}
          onClose={handleDrawerToggle}
          ModalProps={{ keepMounted: true }}
          sx={{
            display: { xs: 'block', sm: 'none' },
            '& .MuiDrawer-paper': {
              width: '20%', // Drawer takes full screen
              height: '100vh',
              boxSizing: 'border-box',
              display: 'flex',
              justifyContent: 'flex-start', // Align to left
              alignItems: 'flex-start',
              padding: 2,
            },
          }}
        >
          <Box
            sx={{
              width: 140, 
              display: 'flex',
              flexDirection: 'column',
              gap: 2, 
              height: '100%',
              paddingTop: 8, 
            }}
          >
            <SideBar /> 
          </Box>
        </Drawer>

        <Box
          sx={{
            width: 120,
            display: { xs: 'none', sm: 'block' },
            flexShrink: 0,
          }}
        >
          <SideBar />
        </Box>

      
        <Box
          sx={{
            flex: 1,
            display: 'flex',
            flexDirection: 'column',
            overflow: 'auto',
          }}
        >
         
          <Box sx={{ display: { xs: 'flex', sm: 'none' }, p: 1 }}>
            <IconButton onClick={handleDrawerToggle}>
              <MenuIcon />
            </IconButton>
          </Box>

          <CustomAppBar />
          <Box sx={{display: 'flex',justifyContent: 'space-between',paddingRight:'20px',marginTop:'10px'
    }}>
     
      <Box sx={{ flex: 1, maxWidth: 200 }}> 
        <SearchInputBox />
      </Box>
      <Box>
        <MyButton>{t('button.add')}</MyButton>
      </Box>
    </Box>
    <QueryClientProvider client={queryClient}>
          <UserListWithDepartments />
          </QueryClientProvider>
        </Box>
      </Box>
    </I18nextProvider>
  );
}

export default App;