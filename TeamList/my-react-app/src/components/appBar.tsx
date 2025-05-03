import React from "react";
import {AppBar,Toolbar,Typography,IconButton,Breadcrumbs,Link,Box,} from "@mui/material";
import NotificationsNoneOutlinedIcon from '@mui/icons-material/NotificationsNoneOutlined';
import EmailOutlinedIcon from '@mui/icons-material/EmailOutlined';
import ArrowForwardIosIcon from "@mui/icons-material/ArrowForwardIos";
import {LanguageButton} from "./languageButton";
import { useTranslation } from 'react-i18next';
const CustomAppBar: React.FC = () => {
    const { t } = useTranslation();
    return(
        
        <AppBar  position="static" color="default" elevation={0}>
        <Toolbar sx={{ justifyContent: "space-between" }}>
    <Box>
    <Typography variant="subtitle1" fontWeight="bold" align="left">
      {t('appBar.teamList')}
    </Typography>
    <Breadcrumbs
      separator={<ArrowForwardIosIcon sx={{ fontSize: '10px' }} />}
      aria-label="breadcrumb"
      sx={{ fontSize: 13 }}
    >
      <Link underline="hover" color="inherit" href="#">
        {t('appBar.adminDashboard')}
      </Link>
      <Typography color="text.primary" sx={{ fontSize: 13 }}>
        {t('appBar.teamList')}
      </Typography>
    </Breadcrumbs>
  </Box>
  <Box display="flex" alignItems="center">
    <IconButton color="default">
      <NotificationsNoneOutlinedIcon fontSize="small" />
    </IconButton>
    <IconButton color="default">
      <EmailOutlinedIcon fontSize="small" />
    </IconButton>
    <LanguageButton />
  </Box>
</Toolbar>

</AppBar>
    )
};
  
  export default CustomAppBar;