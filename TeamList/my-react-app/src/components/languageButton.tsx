import US from "country-flag-icons/react/3x2/US";
import FR from 'country-flag-icons/react/3x2/FR';
import DE from 'country-flag-icons/react/3x2/DE';
import { Select, MenuItem, SelectChangeEvent } from '@mui/material';
import React from "react";
import { useTranslation } from 'react-i18next';

export const LanguageButton: React.FC = () => {
    const { i18n } = useTranslation();
    const [language, setLanguage] = React.useState(i18n.language);

    const handleLanguageChange = (event: SelectChangeEvent) => {
        const newLanguage = event.target.value;
        setLanguage(newLanguage);
        i18n.changeLanguage(newLanguage); 
        localStorage.setItem('i18nextLng', newLanguage); 
    };
    return (
        <Select
            value={language}
            onChange={handleLanguageChange}
            size="small"
            sx={{ 
                ml: 2, 
                minWidth: 20,
                '& .MuiSelect-select': {
                    display: 'flex',
                    alignItems: 'center',
                    padding: '6px 12px !important'
                }
            }}
            renderValue={(selected) => {
                switch (selected) {
                    case 'fr': return <FR style={{ width: 15 }} />;
                    case 'de': return <DE style={{ width: 15 }} />;
                    default: return <US style={{ width: 15 }} />;
                }
            }}
        >
            <MenuItem value="en">
                <US style={{ width: 15, marginRight: 8 }} />
                English
            </MenuItem>
            <MenuItem value="fr">
                <FR style={{ width: 15, marginRight: 8 }} />
                Français
            </MenuItem>
            <MenuItem value="de">
                <DE style={{ width: 15, marginRight: 8 }} />
                Deutsch
            </MenuItem>
        </Select>
    );
}