import { useEffect, useState } from "react";

function App() {
  const title = 'Welcom to Reactivities'
  // use react hooks to remember state
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    // fetch data from the server
    fetch('https://localhost:5001/api/activities')

      .then(response => response.json())
      .then(data => {
        // set the state with the data
        setActivities(data);
      })
      .catch(error => {
        console.error('Error fetching activities:', error);
      });
  }, []);


  return (
    <div >
      <h3 className="app" style={{ color: 'red' }}>{title}</h3>
      <h2>Activities</h2>
      <ul>
        {activities.map(activity => (
          <li key={activity.id}>{activity.title}</li>
        ))}
      </ul>

      <ul></ul>
    </div>
  )
}

export default App
