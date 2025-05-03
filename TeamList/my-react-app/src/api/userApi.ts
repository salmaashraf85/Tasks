
export async function fetchUser(page: number, results: number) {
    const response = await fetch(
      `https://randomuser.me/api?page=${page}&results=${results}`
    );
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    return await response.json();
  }
  

