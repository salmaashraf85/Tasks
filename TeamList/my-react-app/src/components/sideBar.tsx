import {Box} from "@mui/material";
import GridViewOutlinedIcon from '@mui/icons-material/GridViewOutlined';
import ViewModuleOutlinedIcon from '@mui/icons-material/ViewModuleOutlined';
import SupervisorAccountOutlinedIcon from '@mui/icons-material/SupervisorAccountOutlined';
import ArticleOutlinedIcon from '@mui/icons-material/ArticleOutlined';
import FolderOutlinedIcon from '@mui/icons-material/FolderOutlined';
import Inventory2OutlinedIcon from '@mui/icons-material/Inventory2Outlined';
import TodayOutlinedIcon from '@mui/icons-material/TodayOutlined';
import SettingsOutlinedIcon from '@mui/icons-material/SettingsOutlined';
import Logo from '../assets/logo.png';
export const SideBar: React.FC = () => {
    return(
<Box
  sx={{
    backgroundColor: 'white', display: 'flex', flexDirection: { xs: 'row', sm: 'column' },
    gap: { xs: '10px', sm: '20px' }, alignItems: 'center',
    borderRadius: { xs: 0, sm: '12px' }, width: { xs: '100%', sm: 'auto' },
    height: { xs: 'auto', sm: '100%' },justifyContent: { xs: 'space-around', sm: 'flex-start' },
    py: { xs: 1, sm: 0 },
  }}
>
  <Box
    component="img"
    src={Logo}
    alt="Logo"
    sx={{
      width: { xs: 40, sm: 50 },
      display: { xs: 'none', sm: 'block' },
      pb: { xs: 0, sm: '150%' },
      borderRadius: '12px',
    }} />
      <GridViewOutlinedIcon sx={{ color: 'grey.700', opacity: 0.9,borderRadius: '12px',fontSize: { xs: 'medium', sm: 'large' }}}></GridViewOutlinedIcon>
      <ViewModuleOutlinedIcon sx={{ color: 'grey.700', opacity: 0.9,borderRadius: '12px',fontSize:{ xs: 'medium', sm: 'large' }}}></ViewModuleOutlinedIcon>
      <SupervisorAccountOutlinedIcon sx={{ color: 'grey.700', opacity: 0.9,borderRadius: '12px',fontSize:{ xs: 'medium', sm: 'large' }}}></SupervisorAccountOutlinedIcon>
      <ArticleOutlinedIcon sx={{ color: 'grey.700', opacity: 0.9,borderRadius: '12px',fontSize:{ xs: 'medium', sm: 'large' }}}></ArticleOutlinedIcon>
      <FolderOutlinedIcon sx={{ color: 'grey.700', opacity: 0.9,borderRadius: '12px',fontSize:{ xs: 'medium', sm: 'large' }}}></FolderOutlinedIcon>
      <Inventory2OutlinedIcon sx={{ color: 'grey.700', opacity: 0.9,borderRadius: '12px',fontSize:{ xs: 'medium', sm: 'large' }}}></Inventory2OutlinedIcon>
      <TodayOutlinedIcon sx={{ color: 'grey.700', opacity: 0.9,borderRadius: '12px',fontSize:{ xs: 'medium', sm: 'large' }}}></TodayOutlinedIcon>
      <SettingsOutlinedIcon  sx={{ color: 'grey.700', opacity: 0.9,borderRadius: '12px',fontSize:{ xs: 'medium', sm: 'large' }}}></SettingsOutlinedIcon>
      </Box>
    )}