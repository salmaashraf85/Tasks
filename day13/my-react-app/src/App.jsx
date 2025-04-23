import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import MyButton from './components/button'
import MyTextField from './components/Input'
import DeleteIcon from '@mui/icons-material/Delete';
import DoneIcon from '@mui/icons-material/Done';
function App() {
  const [count, setCount] = useState(0)
  const [tasks, setTasks] = useState([])
  const [taskInput, setTaskInput] = useState('')


  const addTask=()=>{
    if(taskInput.trim()){
    setTasks([...tasks,{text:taskInput,isDone:false}])
    setTaskInput('');
    }
  }
  const deleteTask=(index)=>{
    const filtered= tasks.filter((_,i)=>i !==index);
    setTasks(filtered);
   };

   const completeTask=(index)=>{
    const completed= tasks.map((task,i)=>
      i!==index ? task : {...task,isDone: !task.isDone}
    )
    setTasks(completed);
   };
  return (
    <>
          <div style={{ display: 'flex', flexDirection: 'row', gap: '1rem'}}>
         <MyTextField sx={{ width: '40ch' }} placeholder='Add a new task' value={taskInput} onChange={(e) => setTaskInput(e.target.value)}></MyTextField>
         <MyButton onClick={addTask}>ADD</MyButton>
        </div>
        
       
        
        {tasks.map((task, index) => (
        <div key={index} style={{ display: 'flex', alignItems: 'center' }}>
          <p style={{
            flex:'1',
            textAlign:'left',
            ...(task.isDone && {
              fontStyle: 'italic',
              color: '#888',
              textDecoration: 'line-through',
              opacity: 0.6
            })
            }}>{task.text}</p>
          <DoneIcon onClick={() => completeTask(index)}></DoneIcon>
          <DeleteIcon
            onClick={() => deleteTask(index)}
            style={{
              cursor: 'pointer',
              marginLeft: '1rem',
              color: 'red'
            }}
          />
        </div>
      ))}
      
      
      
      

    </>
    
  )
}

export default App
