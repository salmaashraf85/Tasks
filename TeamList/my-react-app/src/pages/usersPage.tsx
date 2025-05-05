import {useState} from 'react';
import { User } from '../types/user';
import { CustomUserSkeleton } from "../components/tables/UserTableSkeleton"
import DeleteOutlineOutlinedIcon from '@mui/icons-material/DeleteOutlineOutlined';
import DriveFileRenameOutlineOutlinedIcon from '@mui/icons-material/DriveFileRenameOutlineOutlined';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Checkbox, Avatar, Chip, Box, Collapse, TablePagination } from '@mui/material';
import { KeyboardArrowDown, KeyboardArrowUp } from '@mui/icons-material';
import { IconButton } from '@mui/material';
import { useTranslation } from 'react-i18next';
import {useUsers} from '../services/useQuery'

export default function UserList() {

  const { t } = useTranslation();
  const [expandedId, setExpandedId] = useState<string | null>(null);
  const [apiPage, setPage] = useState(1);
  const [rowsPerPage, setRowsPerPage] = useState(5);

  const { data: users, isLoading, error } = useUsers(apiPage,rowsPerPage);

  const toggleExpand = (id: string) => {
    setExpandedId(expandedId === id ? null : id);
  };


  if (isLoading) {
    return (
      <Box p={4}>
        <CustomUserSkeleton />
      </Box>
    );
  }
  
  if (error) {
    return <div>Error: {error.message}</div>;
  }

  return (
    <Box sx={{ overflowX: 'auto' }}>
      <Box p={2}>
        <TableContainer component={Paper} elevation={0}>
          <Table aria-label="user table">
            <TableHead>
              <TableRow sx={{ color: 'text.secondary' }}>
                <TableCell padding="checkbox">
                </TableCell>
                <TableCell sx={{ fontWeight: 'bold', fontSize: 'medium' }} >{t('table.headers.name')}</TableCell>
                <TableCell sx={{ fontWeight: 'bold', fontSize: 'medium' }}>{t('table.headers.position')}</TableCell>
                <TableCell sx={{ fontWeight: 'bold', fontSize: 'medium' }} >{t('table.headers.email')}</TableCell>
                <TableCell sx={{ fontWeight: 'bold', fontSize: 'medium' }} >{t('table.headers.phone')}</TableCell>
                <TableCell sx={{ fontWeight: 'bold', fontSize: 'medium', paddingLeft: '30px' }}>{t('table.headers.status')}</TableCell>
                <TableCell sx={{ fontWeight: 'bold', fontSize: 'medium' }}>{t('table.headers.edit')}</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {users.map((user:User) => (
                <>
                  <TableRow>
                    <TableCell padding="checkbox">
                      <Box sx={{ display: 'flex', alignItems: 'center', gap: 1 }}>
                        <Checkbox
                          size="small"
                        />
                        <IconButton
                          size="small"
                          onClick={() => {
                            toggleExpand(user.email);
                          }}
                          sx={{ p: 0.5 }}
                        >
                          {expandedId === user.email ? <KeyboardArrowUp /> : <KeyboardArrowDown />}
                        </IconButton>
                      </Box>
                    </TableCell>
                    <TableCell>
                      <Box display="flex" alignItems="center" gap={2}>
                        <Avatar
                          src={user.picture.thumbnail}
                          alt={`${user.name.first} ${user.name.last}`}
                          sx={{ width: 32, height: 32 }}
                        />
                        {`${user.name.first} ${user.name.last}`}
                      </Box>
                    </TableCell>
                    <TableCell>{user.position}</TableCell>
                    <TableCell>{user.email}</TableCell>
                    <TableCell>{user.phone}</TableCell>
                    <TableCell>
                      <Chip
                        label={user.status}
                        size="small"
                        sx={{
                          backgroundColor: user.status === 'Full Time' ?
                            'rgba(144, 238, 144, 0.4)' : 'rgba(255, 200, 130, 0.3)',
                          color: user.status === 'Full Time' ?
                            'success.light' : 'warning.light',
                          paddingX: '10px'
                        }}
                      />
                    </TableCell>
                    <TableCell>
                      <Box>
                        <DriveFileRenameOutlineOutlinedIcon sx={{ fontSize: 'large', pr: '20px', color: 'grey' }}></DriveFileRenameOutlineOutlinedIcon>
                        <DeleteOutlineOutlinedIcon
                          sx={{ fontSize: 'large', color: 'grey' }}></DeleteOutlineOutlinedIcon>
                      </Box>
                    </TableCell>
                  </TableRow>

                  <TableRow>
                    <TableCell colSpan={6} style={{ padding: 0 }}>
                      <Collapse in={expandedId === user.email} timeout="auto" unmountOnExit>
                        <Box px={20} py={3}>
                          <TableContainer component={Paper} elevation={0}>
                            <Table size="small" aria-label="user details table">
                              <TableHead>
                                <TableRow>
                                  <TableCell colSpan={2} sx={{ fontWeight: 'bold', fontSize: 'small', color: 'rgba(71, 70, 70, 0.9)' }}>{t('table.headers.location')}</TableCell>
                                  <TableCell sx={{ width: '20px' }} />
                                  <TableCell colSpan={2} sx={{ fontWeight: 'bold', fontSize: 'small', color: 'rgba(71, 70, 70, 0.9)' }}>{t('table.headers.birthday')}</TableCell>
                                  <TableCell sx={{ width: '20px' }} />
                                  <TableCell sx={{ fontWeight: 'bold', fontSize: 'small', color: 'rgba(71, 70, 70, 0.9)', whiteSpace: 'nowrap' }}>HR {t('table.headers.year')}</TableCell>
                                  <TableCell sx={{ width: '20px' }} />
                                  <TableCell colSpan={2} sx={{ fontWeight: 'bold', fontSize: 'small', color: 'rgba(71, 70, 70, 0.9)' }}>{t('table.headers.address')}</TableCell>
                                </TableRow>
                              </TableHead>
                              <TableBody>
                                <TableRow>
                                  <TableCell colSpan={2} sx={{ color: 'GrayText', fontSize: 'small', whiteSpace: 'nowrap' }} >
                                    {`${user.location.street.number} street, ${user.location.street.name} `}
                                  </TableCell>
                                  <TableCell sx={{ width: '20px' }} />
                                  <TableCell colSpan={2} sx={{ color: 'GrayText', fontSize: 'small' }}>
                                    {new Date(user.dob.date).toLocaleDateString()}
                                  </TableCell>
                                  <TableCell sx={{ width: '20px' }} />
                                  <TableCell sx={{ color: 'GrayText', fontSize: 'small', whiteSpace: 'nowrap' }}>
                                    {`${user.registered.age} ${t('table.headers.year')}`}
                                  </TableCell>
                                  <TableCell sx={{ width: '20px' }} />
                                  <TableCell colSpan={2} sx={{ color: 'GrayText', fontSize: 'small', whiteSpace: 'nowrap' }}>
                                    {`${user.location.state}, ${user.location.city}, ${user.location.country}`}
                                  </TableCell>
                                </TableRow>
                              </TableBody>
                            </Table>
                          </TableContainer>
                        </Box>
                      </Collapse>
                    </TableCell>
                  </TableRow>
                </>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
        <TablePagination
  component="div"
  count={100} 
  page={apiPage - 1}
  onPageChange={(_, newPage) => {
    setPage(newPage + 1);
  }}
  rowsPerPage={rowsPerPage}
  onRowsPerPageChange={(e) => {
    setRowsPerPage(parseInt(e.target.value, 10));
    setPage(1);
  }}
  rowsPerPageOptions={[5, 10, 25]}
  labelDisplayedRows={({ from, to, count }) => `${from}-${to} of ${count}`}
  sx={{
    '& .MuiTablePagination-actions': {
      marginLeft: 'auto',
    },
    '& .MuiTablePagination-toolbar': {
      paddingLeft: 0,
    },
  }}
  showFirstButton
  showLastButton

        />
      </Box>
    </Box>
  )
}