import { List, ListItem, ListItemText, Typography } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";

function App() {
  const title = 'Welcome to Reactivities'
  // use react hooks to remember state
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    // fetch data from the server
    axios.get<Activity[]>('https://localhost:5001/api/activities')

      .then(response => setActivities(response.data))

    return () => { }
    }, []);


  return (
    < >
      <Typography variant='h1' className="app" style={{ color: 'blue' }}>{title}</Typography>
      <Typography variant='h3'>Activities</Typography>
      <List>
        {activities.map(activity => (
          <ListItem key={activity.id}>
            <ListItemText>{activity.title}</ListItemText>
          </ListItem>
        ))}
      </List>

      <ul></ul>
    </>
  )
}

export default App
