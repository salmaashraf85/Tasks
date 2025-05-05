import { useQuery } from '@tanstack/react-query';
import { fetchUser } from '../api/userApi';
import { User } from '../types/user';

export function useUsers(page: number, rowsPerPage: number) {
    
  return useQuery({
    queryKey: ['users', page, rowsPerPage],
    queryFn: () => fetchUser(page, rowsPerPage),
    select: (data) => {
      return data.results.map((user: User) => ({
        ...user,
        position: assignPosition(),
        status: assignStatus(),
      }));
    },
  });
}


function assignPosition(): string {
  const positions = ['Analyst', 'Developer', 'Tester', 'Manager', 'Fresher'];
  return positions[Math.floor(Math.random() * positions.length)];
}

function assignStatus(): string {
  const stat = ['Full Time', 'Part Time'];
  return stat[Math.floor(Math.random() * stat.length)];
}