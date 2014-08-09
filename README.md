badapple
========

In your current Activity, create a new Intent:

Intent i = new Intent(getApplicationContext(), NewActivity.class);
i.putExtra("new_variable_name","value");
startActivity(i);
Then in the new Activity, retrieve those values:

Bundle extras = getIntent().getExtras();
if (extras != null) {
    String value = extras.getString("new_variable_name");
}
Use this technique to pass variables from one Activity to the other.
