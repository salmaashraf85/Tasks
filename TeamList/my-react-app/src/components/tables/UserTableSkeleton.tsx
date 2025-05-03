import {Table,TableBody,TableCell,TableContainer,TableHead,TableRow,Paper, Box,Skeleton} from '@mui/material';
export function CustomUserSkeleton() {
    return (
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell><Skeleton width={40} /></TableCell>
              <TableCell><Skeleton width={120} /></TableCell>
              <TableCell><Skeleton width={100} /></TableCell>
              <TableCell><Skeleton width={180} /></TableCell>
              <TableCell><Skeleton width={100} /></TableCell>
              <TableCell><Skeleton width={80} /></TableCell>
              <TableCell><Skeleton width={60} /></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {[1, 2, 3, 4, 5].map((row) => (
              <TableRow key={row}>
                <TableCell><Skeleton variant="circular" width={40} height={40} /></TableCell>
                <TableCell>
                  <Box display="flex" gap={2} alignItems="center">
                    <Skeleton variant="circular" width={40} height={40} />
                    <Skeleton variant="text" width={100} />
                  </Box>
                </TableCell>
                <TableCell><Skeleton variant="text" /></TableCell>
                <TableCell><Skeleton variant="text" /></TableCell>
                <TableCell>
                  <Skeleton 
                    variant="rectangular" 
                    width={80} 
                    height={24} 
                    sx={{ borderRadius: 16 }} 
                  />
                </TableCell>
                <TableCell>
                  <Skeleton variant="rectangular" width={60} height={32} />
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    );
  }