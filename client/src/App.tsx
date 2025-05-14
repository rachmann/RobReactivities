import { Box, Stack, List, ListItem, ListItemIcon, ListItemText, Typography, Accordion, AccordionSummary, AccordionDetails } from "@mui/material";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import CircleIcon from "@mui/icons-material/Circle";
import axios from "axios";
import { useEffect, useState } from "react";

function App() {
  const title = "Welcome to Reactivities";
  const [activities, setActivities] = useState<Activity[]>([]);
  const [expanded, setExpanded] = useState(true);

  useEffect(() => {
    // Fetch data from the server
    axios.get<Activity[]>("https://localhost:5001/api/activities")
      .then(response => setActivities(response.data));

    return () => { };
  }, []);

  useEffect(() => {
    const checkHeight = () => {
      const screenHeight = window.innerHeight;
      const contentHeight = document.getElementById("activities-list")?.offsetHeight || 0;
      setExpanded(contentHeight < screenHeight * 0.62); // Collapse when content exceeds 70% of screen height
    };

    window.addEventListener("resize", checkHeight);
    checkHeight(); // Check on mount

    return () => window.removeEventListener("resize", checkHeight);
  }, [activities]); // Runs when activities update

  return (
    <Box sx={{ padding: 2 }}>
      <Typography variant="h1" sx={{ color: "blue", textAlign: "center" }}>
        {title}
      </Typography>

      <Accordion expanded={expanded}>
        <AccordionSummary expandIcon={<ExpandMoreIcon />} onClick={() => setExpanded(!expanded)}>
          <Typography variant="h3">Activities</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <Stack spacing={2} id="activities-list">
            <List>
              {activities.map(activity => (
                <ListItem key={activity.id}>
                  <ListItemIcon>
                    <CircleIcon sx={{ fontSize: "small", color: "grey" }} />
                  </ListItemIcon>
                  <ListItemText primary={activity.title} />
                </ListItem>
              ))}
            </List>
          </Stack>
        </AccordionDetails>
      </Accordion>
    </Box>
  );
}

export default App;
