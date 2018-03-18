
# Develop while-based iteration statement from if-based thinking


To to express repetitive process, it is sometime easier to start with "if" statement and then convert to "while" statement

Say we have an array:
[2, 5, 3, 7, 8]

The objective is to find if a certain value, say 3, exists or not. An initial if-based logic may look like this:


```
1: if current is equal to 3
2:  stop looking, indicate that we found it
3: else
4:  update current by proceeding to the next adjacent elemenet
5:  go back to if
6: we didn't find it. indicate that we did not find it
```

Now, consider transformation steps to convert if-based ieration to a while-based loop:

- Change `if` to `while`
- Invert the Boolean expression: `current is equal to 3` to `current is not equal to 3`
- Remove line 2
- remove line 3
- keep line 4 - we need control statement to "move to next one"
- remove line 5
- keep line 6

By applying this transformation, we got:

```
1: while current is not equal to 3
4:  update current by proceeding to the next adjacent element
6: current must be 3
```

By progressively thinking from if-based thinking to while-baesd thinkng, I can more easily come up with a correct iteration statement.